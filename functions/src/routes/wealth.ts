import { Router, Request, Response } from 'express';
import { Rank } from '../models/rank';
import { DataSnapshot } from '@firebase/database-types';

import { App } from '../firebase';

const router = Router();
const db = App.database();

/**
 * Gets a Wealth leaderboard
 */
router.get('/', (req: Request, res: Response) => {
  const AVAILABLE_FILTERS = ['WEALTH', 'DAYS'];
  const DEFAULT_FILTER = AVAILABLE_FILTERS[0];

  // ?. is called optional chaining.
  let filter = req.params.filter?.toUpperCase();
  if (!AVAILABLE_FILTERS.includes(filter)) {
    // If request doesn't define a filter or defines an incorrect filter
    filter = DEFAULT_FILTER;
  }
  filter = filter.toLowerCase();

  // Firebase doesn't offer descending order. Need to reverse the output.
  const ref = db.ref('/ranks').orderByChild(filter).limitToLast(100);
  ref
    .once('value')
    .then((snapshot: DataSnapshot) => {
      if (snapshot.val() !== null) {
        let arr: any[] = [];

        /**
         * DataSnapshot.val() doesn't return an ordered value, so it needs to be iterated like below.
         * The Object Key is stripped in this process as intended.
         */
        snapshot.forEach(function (el) {
          arr.push(el.val());
        });
        // The value we get isn't ordered, so the reverse is done here.
        arr = arr.reverse();

        res.status(200).send(arr);
      } else {
        // There are no saved data available. DB is empty.
        res.sendStatus(204);
      }
    })
    .catch((error) => {
      console.error(error);
      res.sendStatus(500);
    });
});

/**
 * Saves ranking to the leaderboard if it beats any existing rank.
 */
router.post('/', (req: Request, res: Response) => {
  // @TODO: Implement top 100 only.

  const name: string = req.body.name;
  const days: number = req.body.days;
  const wealth: number = req.body.wealth;

  if (name && days && wealth) {
    const rank: Rank = new Rank(name, days, wealth);

    const ref = db.ref('/ranks');
    ref
      .push(rank)
      .then(() => {
        res.status(200).send({ msg: 'Success!' });
        return;
      })
      .catch((error: any) => {
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
