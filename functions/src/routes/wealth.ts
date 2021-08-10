import { Router, Request, Response } from 'express';
// const fb = require('../firebase');
// const db = fb.database();

const router = Router();

// Test
const WealthRouter: Router = router.get('/', (req: Request, res: Response) => {
  res.status(200).send({ result: true });
  /**
  const ref = db.ref('/subreddit');
  ref.once('value').then((snapshot) => {
    res.status(200).send(snapshot.val());
    return;
  }).catch((error) => {
    console.error(error);
    res.status(500).send();
  });
   */
});

export { WealthRouter };
