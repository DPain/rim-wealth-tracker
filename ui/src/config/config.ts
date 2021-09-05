import Dev from '@/config/dev';
import Prod from '@/config/prod';

export default function () {
  switch (process.env.NODE_ENV) {
    case 'production':
    case 'PRODUCTION':
    case 'prod':
    case 'PROD':
      return Prod;
    default:
      return Dev;
  }
}
