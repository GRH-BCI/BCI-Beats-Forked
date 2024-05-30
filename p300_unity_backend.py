import os
import sys
from bci_essentials.erp_data import ErpData
from bci_essentials.classification.erp_rg_classifier import ErpRgClassifier
from bci_essentials.io.lsl_sources import LslEegSource, LslMarkerSource
from bci_essentials.io.lsl_messenger import LslMessenger
from pylsl import StreamInlet, resolve_stream
import pandas as pd
import numpy as np
from datetime import datetime
#import threadingW


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



# # Connect the streams
# test_erp.stream_online_eeg_data(timeout=5,
#                            max_eeg_samples=1000000,
#                            max_marker_samples=100000,
#                            eeg_only=False,
#                            subset=[])  # you can also add a subset here
# test_erp.pull_data_from_stream(include_markers=False, include_eeg=True, return_eeg=False)


# Run main
test_erp.setup(
    online=True,
    training=True,
    pp_low=1, #1 vs 0.1
    pp_high=5, #5 vs 10?
    pp_order=3, #3 vs 5? 
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