import * as functions from 'firebase-functions';
import * as express from 'express';
import * as cors from 'cors';

const app = express();

const whitelist = [
  'http://localhost',
  'https://rim-wealth-tracker-322501.firebaseapp.com',
  'https://rim-wealth-tracker-322501.web.app',
];
const corsOptionsDelegate = function (req: any, callback: any) {
  let corsOptions;
  if (whitelist.indexOf(req.header('Origin')) !== -1) {
    // reflect (enable) the requested origin in the CORS response
    corsOptions = { origin: true };
  } else {
    // disable CORS for this request
    corsOptions = { origin: false };
  }
  // callback expects two parameters: error and options
  callback(null, corsOptions);
};

app.use(cors(corsOptionsDelegate));

// Debug only.
// app.use(cors('*'));

// parse application/x-www-form-urlencoded
app.use(express.urlencoded({ extended: false }));
// parse application/json
app.use(express.json());

// Routes
import { WealthRouter } from './routes/wealth';

/**
 * Exposed APIs
 */
app.use('/wealth', WealthRouter);

/**
 * Health Check.
 */
app.get('/', (req: any, res: any) => {
  res.status(200).send();
});

// End of exposed API.

// Expose Express API as a single Cloud Function:
exports.api = functions.https.onRequest(app);
