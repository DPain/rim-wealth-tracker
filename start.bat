cd functions
call npm run build
cd ../ui
cmd /c npm run start
firebase emulators:start