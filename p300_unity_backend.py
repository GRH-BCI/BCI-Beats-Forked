from bci_essentials.bci_data import ERP_data
from bci_essentials.classification.erp_rg_classifier import ERP_rg_classifier

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
    covariance_estimator="lwf",
)

# Connect the streams
test_erp.stream_online_eeg_data()  # you can also add a subset here

# Run main
test_erp.main(
    online=True,
    training=True,
    pp_low=1,
    pp_high=5,
    pp_order=3,
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