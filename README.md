# SourceCodeStudioTest Application

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Notes](#notes)
- [Screenshots](#screenshots)

## Introduction

The SourceCodeStudioTest Application is a simple .NET MAUI application based on the following brief:

- The App has two screens and navigation between them
- The first screen should show a welcome message and the users current location
- The second screen should show a random dog image using the following API

```bash
dog.ceo/api/breeds/image/random 
```

## Features

- **Current Location**: Find the user's current location and displays it on the view.
- **Maps**: Open the current location on the Maps App.
- **Distance from HeadQuarters**: Calculates the user's distance from the company's HeadQuarters in Bury St Edmunds.
- **Dogs**: Find as many dogs as you like.

## Notes

The App has been tested on the Android Emulator.
Given more time, I would have improved the overall UX with error messages based on possible networking or geolocation issues encountered. Also I would have added a Unit Test project for code coverage and reduce potential bugs.

## Screenshots

Check out some screenshots from the App below:

![SourceCodeStudioTest](/Screenshots/04.png)
![SourceCodeStudioTest](/Screenshots/01.png)
![SourceCodeStudioTest](/Screenshots/02.png)
![SourceCodeStudioTest](/Screenshots/03.png)
