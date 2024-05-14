import os
import sys
from bci_essentials.bci_data import ERP_data
from bci_essentials.classification.erp_rg_classifier import ERP_rg_classifier
from pylsl import StreamInlet, resolve_stream
import pandas as pd
import numpy as np
from datetime import datetime
import threading


# Add parent directory to path to access bci essentials
sys.path.append(os.path.join(os.path.dirname(os.path.abspath(__file__)), os.pardir))


# Initialize the ERP
test_erp = ERP_data()

# Set classifier settings ()
test_erp.classifier = ERP_rg_classifier()  # you can add a subset here

# Set some settings
test_erp.classifier.set_p300_clf_settings(
    n_splits=5,
    lico_expansion_factor=1,
    oversample_ratio=0,
    undersample_ratio=0,
    covariance_estimator="lwf", # oas????
)

# Connect the streams
test_erp.stream_online_eeg_data(timeout=5,
                           max_eeg_samples=1000000,
                           max_marker_samples=100000,
                           eeg_only=False,
                           subset=[])  # you can also add a subset here
test_erp.pull_data_from_stream(include_markers=False, include_eeg=True, return_eeg=False)


# Run main
test_erp.main(
    online=True,
    training=True,
    pp_low=1, #0.1?
    pp_high=5, #10?
    pp_order=3, #5? 
    plot_erp=False,
    window_start=0.0,
    window_end=0.8,
    print_markers=True,
    print_training=True,
    print_fit=False,
    print_performance=True,
    print_predict=True,
    max_decisions=50,
    #max_windows_per_option=10,
    #max_num_options=16
)