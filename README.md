# CSCE361FinalProject


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
<<<<<<< Updated upstream
 docker build -t cg -f CardGame\\Dockerfile .
```

=======
docker build -t cg .
```
>>>>>>> Stashed changes
