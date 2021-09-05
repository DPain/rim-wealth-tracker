// URL: 'https://us-central1-rim-wealth-tracker-322501.cloudfunctions.net/api'
// Local Testing URL: 'https://us-central1-rim-wealth-tracker-322501.cloudfunctions.net/api'
const server_url =
  'http://localhost:5001/rim-wealth-tracker-322501/us-central1/api'.replace(
    new RegExp('/+$'),
    ''
  ); // Removes trailing slashes.

const config = {
  server_url: server_url,
  wealth_url: `${server_url}/wealth`,
  news_url: `${server_url}/news`,
};

export default config;
