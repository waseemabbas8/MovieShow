<?php
session_start();
require_once('twitteroauth/twitteroauth.php'); //Path to twitteroauth library
 
$twitteruser = "@OliaGozha";
$notweets = 10;
$consumerkey = "oN4CjnKPYKhtd9b9UYng";
$consumersecret = "T2IjQ7gyYWZIohfmNwv0mUF3piTgn7e4f8jbf1I9wU";
$accesstoken = "89252733-7jIxArc5m0vFePY4shQbTojMIP7qs8niTqEjYKuPQ";
$accesstokensecret = "3aw4VOLpDk0mUIenFkfEH9tERi3XMJqxSBfosLfNJypgl";
 
function getConnectionWithAccessToken($cons_key, $cons_secret, $oauth_token, $oauth_token_secret) {
  $connection = new TwitterOAuth($cons_key, $cons_secret, $oauth_token, $oauth_token_secret);
  return $connection;
}
  
$connection = getConnectionWithAccessToken($consumerkey, $consumersecret, $accesstoken, $accesstokensecret);
$tweets = $connection->get("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=".$twitteruser."&count=".$notweets);
 
echo json_encode($tweets);
?>