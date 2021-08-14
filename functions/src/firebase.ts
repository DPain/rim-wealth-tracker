import * as admin from 'firebase-admin';

const App = admin.initializeApp({
  credential: admin.credential.applicationDefault(),
  databaseURL: 'https://rim-wealth-tracker-322501-default-rtdb.firebaseio.com',
});

export { App };
