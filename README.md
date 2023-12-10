# CSCE361FinalProject

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

