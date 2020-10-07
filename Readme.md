# VideoMasking

This is a simple program that covers the border of your screen with black masking rectangles.

It's meant to be used with HTPC media players and projectors so you can cover up the video area that might over-spill past the edges of your projector screen.

## Usage

Simply launch the program to start the masking.

##### Hotkeys

Increase Left Masking (Alt+1)  
Decrease Left Masking (Ctrl+1)

Increase Right Masking (Alt+2)  
Decrease Right Masking (Ctrl+2)

Increase Top Masking (Alt+3)  
Decrease Top Masking (Ctrl+3)

Increase Bottom Masking (Alt+4)  
Decrease Bottom Masking (Ctrl+4)

You can launch the program with the "true" command line parameter in order to continuously force the masking to become the active window so it stays on top every second.

Ex: ```VideoMasking.exe "true"```

## Additional notes

VideoMasking automatically waits for certain programs to close and it will close with them.  The programs that it's designed to wait for are kodi, mpc-hc64, and madHcCtrl (madVR).