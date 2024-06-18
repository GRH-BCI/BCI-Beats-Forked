import os
import sys
from datetime import datetime
import threading


from bci_essentials.erp_data import ErpData
from bci_essentials.classification.erp_rg_classifier import ErpRgClassifier
from bci_essentials.io.lsl_sources import LslEegSource, LslMarkerSource
from bci_essentials.io.lsl_messenger import LslMessenger

from pylsl import StreamInlet, resolve_stream
import pandas as pd
import numpy as np
import mne


# Add parent directory to path to access bci essentials
sys.path.append(os.path.join(os.path.dirname(os.path.abspath(__file__)), os.pardir))


# Initialize the classifier
classifier = ErpRgClassifier()

# Set some settings
classifier.set_p300_clf_settings(
    n_splits=5,
    lico_expansion_factor=1,
    oversample_ratio=0,
    undersample_ratio=0,
    covariance_estimator="oas", # oas????
)

# create LSL sources, these will block until the outlets are present
eeg_source = LslEegSource()
marker_source = LslMarkerSource()
messenger = LslMessenger()

# Initialize the ERP
test_erp = ErpData(classifier, eeg_source, marker_source, messenger)


# Create eeg and marker streams
print("looking for a marker and eeg streams...")
marker_stream = resolve_stream('type', 'LSL_Marker_Strings')
eeg_stream = resolve_stream('type', 'EEG')
marker_inlet = StreamInlet(marker_stream[0])
eeg_inlet = StreamInlet(eeg_stream[0])

global flag
flag = True
file_name = str(datetime.now().strftime("%Y-%m-%d %H-%M-%S"))
path = './data_sets'
if not os.path.exists(path):
    os.mkdir(path)
else:
    print("Folder %s already exists" % path)




def eeg_recorder():
    global flag
    eeg_channel_cnt = int(eeg_inlet.channel_count)
    eeg_data = np.zeros((eeg_channel_cnt, 1))

    eeg_timestamps = np.zeros((1,))
    while flag:
        eeg_sample, eeg_timestamp = eeg_inlet.pull_sample()
        #print("got %s at time %s" % (eeg_sample, eeg_timestamp))
        eeg_sample = np.array(eeg_sample).reshape(eeg_channel_cnt, 1)
        eeg_timestamp = np.array(eeg_timestamp).reshape((1,))
        eeg_data = np.concatenate((eeg_data, eeg_sample), axis=1)
        eeg_timestamps = np.concatenate((eeg_timestamps, eeg_timestamp))
    if not flag:
        eeg_timestamps = eeg_timestamps.reshape((eeg_timestamps.shape[0], 1)).transpose()
        channel_names = list(test_erp.channel_labels)
        eeg_df = pd.DataFrame(np.concatenate((eeg_data, eeg_timestamps), axis=0).transpose(),
                              columns=(channel_names + ['time_stamps']))
        info = mne.create_info(ch_names=channel_names, sfreq=test_erp.fsample, ch_types='eeg')
        raw_array = mne.io.RawArray(data=eeg_data, info=info)
        #mne.export.export_raw(path + str('/' + file_name + '_EEG.edf'), raw_array, overwrite=False)
        eeg_df.to_csv(path + str('/' + file_name + '_EEG.csv'), float_format='{:.7f}'.format)


def marker_recorder():
    global flag
    marker_data = np.zeros((1,))
    marker_timestamps = np.zeros((1,))
    while flag:
        marker_sample, marker_timestamp = marker_inlet.pull_sample()
        #print("got %s at time %s" % (marker_sample[0], marker_timestamp))
        if marker_sample[0] == 'Training Complete':
            flag = False
        if marker_sample[0] == 'Trial Started':
            flag = True
        marker_sample = np.array(marker_sample)
        marker_data = np.concatenate((marker_data, marker_sample))
        marker_timestamp = np.array(marker_timestamp).reshape((1,))
        marker_timestamps = np.concatenate((marker_timestamps, marker_timestamp))
    if not flag:
        marker_data = marker_data.reshape((marker_data.shape[0], 1))
        marker_timestamps = marker_timestamps.reshape((marker_data.shape[0], 1))
        #print(marker_data.shape)
        #print(marker_timestamps.shape)
        marker_out = np.concatenate((marker_data, marker_timestamps), axis=1)
        marker_df = pd.DataFrame(marker_out)
        marker_df.to_csv(path + str('/' + file_name + '_markers.csv'), float_format='{:.7f}'.format)


eeg_recorder_thread = threading.Thread(target=eeg_recorder, args=(), daemon=True)
marker_recorder_thread = threading.Thread(target=marker_recorder, args=(), daemon=True)
eeg_recorder_thread.start()
marker_recorder_thread.start()




# Run main
test_erp.setup(
    online=True,
    training=True,
    pp_low=0.1, #1 vs 0.1
    pp_high=15, #5 vs 10?
    pp_order=5, #3 vs 5? 
    plot_erp=False,
    trial_start=0.0,
    trial_end=0.8,
    # print_markers=True,
    # print_training=True,
    # print_fit=False,
    # print_performance=True,
    # print_predict=True,
    max_decisions=50,
    #max_trials_per_option=10,
    #max_num_options=16
)

test_erp.run()



'''
                # Print the shape of X_train and y_train
                print("Shape of X_train:", X_train.shape)
                print("Shape of y_train:", y_train.shape)

                # Optionally, print the data types
                print("Data type of X_train:", X_train.dtype)
                print("Data type of y_train:", y_train.dtype)

                # Print a small sample of the values (you can adjust the slice to see more or less data)
                print("Sample values from X_train:\n", X_train) #[:2, :, :])  # Adjust the slice as needed
                print("Sample values from y_train:\n", y_train) #[:10])  # Adjust the slice as needed
'''