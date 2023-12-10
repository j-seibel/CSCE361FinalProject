# CSCE361FinalProject

## Project description:
This is Group 11's final project for CSCE 361. We have implemented the card games War and Solitaire using a React frontend and C# backend. 

Open entry, users are prompted to choose between three options: host a game of War, join a game of War, or play solitaire solo.

If War is chosen, then the player can generate their room token and start a game of War or join a game of war. Either will send you to the War page. War is a multiplayer card game that is played between two people. Although the website is capable of hosting tens of different matches simultaneously thanks to websockets. Upon winning the game by reaching five winning hands before your opponent, the screen will update and render a 'player x won' message.

If Solitaire is chosen, then the user is redirected to the solitaire page. The page keeps track of your time taken to finish and records your best time. Upon building your four foundation piles, one for each suit, in ascending order from Ace to King, the page will update and display a 'you win' message.

Below are a set of instructions to get the web app up and running!

# Setting up the React Frontend
This guide will walk you through the steps to start the React app. 
You must have Node.js installed on your computer to run React Applications. (https://nodejs.org/en/download)

## Step 1: Navigate to the frontend/cardgame_frontend folder
`cd` into the frontend/cardgame_frontend folder. This contains all of the React App.

## Step 2: Installing dependencies
Now that we are in the folder. You can run `npm install` to install all of the node packages.

## Step 3: Running the app
We are all ready to run the app! run `npm start` and navigate to `localhost:3000` in your broswer to see the page.

# Setting up the .NET Docker Environment

This guide will walk you through the steps to set up a .NET Docker environment for the project. Download and install Docker from the official website [here](https://www.docker.com/get-started).

## Step 1: Navigate to the App Folder

First, navigate to the "App" folder of your project using the command line. You can do this using the `cd` (change directory) command:

```bash
cd path/to/your/project/App/CardGame
```

## Step 2: Start the container

```bash
docker run  --rm -p 8080:80 cg
```
## Step 3: Update Code

After changing the code the container can be rebuilt with

```bash
 docker build -t cg -f CardGame\\Dockerfile .
```

