A repro of [connect
#3139210](https://connect.microsoft.com/VisualStudio/feedback/details/3139210)
(cross-posted to
[Microsoft/dotnet#579](https://github.com/Microsoft/dotnet/issues/579))
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

**UPDATE**: After filing a “Technical Support” incident through a VS subscription, @Microsoft has acknowledged this bug and stated that a fix will be included in .net-4.7.3.
