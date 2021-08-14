import { Router, Request, Response } from 'express';
import { Rank } from '../models/rank';
import { Reference } from '@firebase/database-types';
// import { DataSnapshot } from '@firebase/database-types';

import { App } from '../firebase';

const router = Router();
const db = App.database();

/**
 * Gets a Wealth leaderboard
 */
router.get('/', (req: Request, res: Response) => {
  // @TODO: Implement.
  res.sendStatus(200);
});

/**
 * Saves ranking to the leaderboard if it beats any existing rank.
 */
router.post('/', (req: Request, res: Response) => {
  // @TODO: Implement.

  const name: string = req.body.name;
  const days: number = req.body.days;
  const wealth: number = req.body.wealth;

  if (name && days && wealth) {
    const rank: Rank = new Rank(name, days, wealth);

    const ref = db.ref('/ranks');
    ref.push(rank).then((snapshot: Reference) => {
      res.status(200).send(snapshot.key);
      return;
    }).catch((error: any) => {
      console.error(error);
      res.status(500).send();
    });
  } else {
    res.status(400).send({
      msg: 'Bad request!',
    });
  }
});

const WealthRouter: Router = router;

export { WealthRouter };
