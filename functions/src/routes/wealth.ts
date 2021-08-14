import { Router, Request, Response } from 'express';
// const fb = require('../firebase');
// const db = fb.database();

const router = Router();

/**
 * Gets a Wealth leaderboard
 */
router.get('/', (req: Request, res: Response) => {
  // @TODO: Implement.
  res.sendStatus(200);
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

router.post('/', (req: Request, res: Response) => {
  // @TODO: Implement.

  const name: string = req.body.name;
  const days: number = req.body.days;
  const wealth: number = req.body.wealth;

  if (name && days && wealth) {
    res.status(200).send({ name: name, days: days, wealth: wealth });
  } else {
    res.status(400).send({
      msg: 'Bad request!',
    });
  }
});

const WealthRouter: Router = router;

export { WealthRouter };
