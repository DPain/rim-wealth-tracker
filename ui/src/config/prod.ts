const server_url =
  'https://us-central1-rim-wealth-tracker-322501.cloudfunctions.net/api'.replace(
    new RegExp('/+$'),
    ''
  ); // Removes trailing slashes.

const config = {
  server_url: server_url,
  wealth_url: `${server_url}/wealth`,
  news_url: `${server_url}/news`,
};

export default config;
