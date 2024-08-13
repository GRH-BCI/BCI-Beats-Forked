##############################################################
##       Imports                                            ##
##############################################################

import os
import sys


from bci_essentials.classification.erp_rg_classifier import ErpRgClassifier
from bci_essentials.io.lsl_sources import LslEegSource, LslMarkerSource
from bci_essentials.io.lsl_messenger import LslMessenger


from bci_essentials.bci_controller import BciController
from bci_essentials.paradigm.p300_paradigm import P300Paradigm
from bci_essentials.data_tank.data_tank import DataTank
from bci_essentials.session_saving import load_classifier


from pylsl import StreamInlet, resolve_stream


# Add parent directory to path to access bci essentials
sys.path.append(os.path.join(os.path.dirname(os.path.abspath(__file__)), os.pardir))


# set BCI essentials hyperparam to True
bci_essentials_model = True



##############################################################
##       BCI Essentials                                     ##
##############################################################

def bci_essentials_setup():

    # create LSL sources, these will block until the outlets are present
    eeg_source = LslEegSource()
    marker_source = LslMarkerSource()
    messenger = LslMessenger()


    paradigm = P300Paradigm()
    data_tank = DataTank()


    # Initialize the classifier
    classifier = ErpRgClassifier()

    # Set some settings
    classifier.set_p300_clf_settings(
        n_splits=5,
        lico_expansion_factor=1,
        oversample_ratio=0,
        undersample_ratio=0,
        covariance_estimator="oas", 
    )

    # Initialize the ERP
    test_erp = BciController(classifier, eeg_source, marker_source, paradigm, data_tank, messenger)

    # Run main
    test_erp.setup(
        online=True
    )

    test_erp.run()



##############################################################
##       Custom Backend                                     ##
##############################################################
def custom_backend_setup():

    # create LSL sources, these will block until the outlets are present
    eeg_source = LslEegSource()
    marker_source = LslMarkerSource()
    messenger = LslMessenger()

    # can initialize preprocessing features here
    paradigm = P300Paradigm()
    data_tank = DataTank()
    
    # Initialize the classifier
    classifier_path = "filename" # must be pickled
    classifier = load_classifier(classifier_path)

    # Initialize the ERP
    test_erp = BciController(classifier, eeg_source, marker_source, paradigm, data_tank, messenger)

    # Run main
    test_erp.setup(
        online=True
    )

    test_erp.run()




##############################################################
##       Driver Code 2                                      ##
##############################################################
def main(bci_essentials_model):

    # run bci essentials or custom backend
    if bci_essentials_model:
        bci_essentials_setup()
    else:
        custom_backend_setup()





##############################################################
##       Driver Code 1                                      ##
##############################################################
if __name__ == '__main__':
    main(bci_essentials_model)



