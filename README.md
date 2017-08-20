A repro of [connect
#3139210](https://connect.microsoft.com/VisualStudio/feedback/details/3139210)
and [SO #45597995](https://stackoverflow.com/questions/45597995).

I am uploading this as a git repo to GitHub because my attempted file
upload to the connect bug never seems to have successfully uploaded
even though I tried twice.

# Repro Instructions

1. Fix the app to point to an actual instance of SQL Server which it can
   authenticate against.
2. Run.
3. Try interacting with the window about 5 seconds after it launches.
   Notice how the window becomes “ (Not Responding)”.
