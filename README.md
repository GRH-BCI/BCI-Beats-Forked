<p align="center">
  <img src="https://github.com/BCI-Beats-NatHacks/BCI-Beats/assets/140631194/d868c503-2faa-4f02-8415-f52d0247aa77" alt="Logo" width="500"/>
</p>

# BCI-Beats
A BCI music composition app, originally designed for NatHacks2023 ([Devpost](https://devpost.com/software/bci-beats) , re-worked in Summer 2024 for usage in Alberta Health Services (Glenrose Rehabilitation Hospital).

# Contributors
- Jared Gourley
- Jake Hennig
- Kaiden Mastel
- Mona Safari
- Nicholas Mellon
- Kai Luedemann


# Setup for running the application out of the box
1. Download the latest release from the releases sidebar in the repo
2. Make sure your headset (must be DSI-24. If you do not have DSI-24, read the setup section below. You will have to launch the app in that manner) is able to be reached with bluetooth (may have to install bluetooth driver and/or plug in bluetooth radio)
3. Launch the _dsi2lslgui_ executable in the _dsi connector_ folder, and write in what port/channel your headset will be on
4. Launch the main executable
5. Connect your headset using the _Connect BCI_ button on the homepage
6. Play!


# Setup for Working with Codebase
1. Clone the BCI Beats GitHub repository
2. Create a virtual environment using
   
   ```python3 -m venv venv```
    
3. Activate the virtual environment and install the requirements for the backend (from bci essentials 0.2.0) with
   ```pip3 install bci-essentials==0.2.0``` *****
   
4. This should install any necessary dependencies. If any are missed, you may have to install these one-by-one if they come up in error messages.
5. Create a Unity project for the repository
6. Install BCI Essentials Unity into the Unity project by following these [instructions](https://github.com/kirtonBCIlab/bci-essentials-unity#install-into-unity-project)
7. Connect your headset to your computer and start an LSL stream
8. Run the LabStreamingLayer backend using

   ```python3 p300_unity_backend.py```
  
9. Start your Unity project




***** As of the bci-essentials 0.2.0 release, you will need to make some modifications to the library for it to work properly.
1. In the file _bci_controller.py_, the current code has the following lines at the beginning of the _step_ function
     ```
        # Initialize the event marker buffer
        self.event_marker_buffer = []
        self.event_timestamp_buffer = []
     ```
     These lines need to be moved to the _init_ function of the _BciController_ class, otherwise the buffer for holding timestamp and marker data will be erased on each step. 
2. In the _erp_rg_classifier.py_ file, you need to add the following code to the _predict_ function, which currently is being passed:

     ```
        proba_mat = self.clf.predict_proba(X)

        proba = proba_mat[:, 1]
        relative_proba = proba / np.amax(proba)

        log_proba = np.log(relative_proba)
        logger.info("log relative probabilities:\n%s", log_proba)

        # the selection is the highest probability
        prediction = int(np.where(proba == np.amax(proba))[0][0])

        self.predictions.append(prediction)
        self.pred_probas.append(proba_mat)

        return Prediction(labels=prediction, probabilities=proba_mat)
     
     ```

3. If you are using a DSI-24 headset, you will need to make additional modifications to remove its trigger channel data.
     First, you must add the following line in the _predict_ function, right above the code you added in step 2:
        
        ```X = X[:, :-1, :]```

     Then, you must add the following code right above the ```self.clf.fit(X_train, y_train)``` line in the _fit_ function (in the same file):
        ```
        non_zero_channels = np.any(X_train != 0, axis=(0, 2))

        X_train = X_train[:, non_zero_channels, :]
        X_test = X_test[:, non_zero_channels, :]

        ```


# Other Misc. Info
  1. If you want to change the settings for P300 training, you can do this. In the main menu screen (in unity), find the _ControllerManager_ Object, which contains a _P300ControllerBehaviour_ object. Here you can change the properties of this object.
  2. If you have your own model you want to use, you can do this. In the _p300_unity_backend.py_ file, there is currently a global hyperparameter _bci_essentials_model_ that is set to True. Set this to false, and navigate to the _custom_backend_setup_ function. Write the path to your classifier where it says to (it must be pickled). Note that this is just a primitive setup that has not undergone rigorous testing. You may have to troubleshoot issues with your own custom model's compatibility, and thus additional backend changes may be needed.
