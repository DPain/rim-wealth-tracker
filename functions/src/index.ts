import functions = require('firebase-functions');
import express = require('express');
import { Router } from 'express';
import cors = require('cors');

const app = express();

const whitelist = [
  'http://localhost',
  'https://breaddit-1ce34.firebaseapp.com',
  'https://breaddit-1ce34.web.app',
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
const wealth: Router = require('./routes/wealth');

/**
 * Exposed APIs
 */
app.use('/wealth', wealth);

/**
 * Health Check.
 */
app.get('/', (req: any, res: any) => {
  res.status(200).send();
});

// End of exposed API.

// Expose Express API as a single Cloud Function:
exports.api = functions.https.onRequest(app);
