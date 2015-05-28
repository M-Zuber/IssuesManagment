# Roadmap
This document will be updated periodically. Each update will attempt to follow the this format:
```
├── Date of update
│   ├── Current Release [number]
│   │   ├── Details
│   │   ├── [Applicable Links/Extra Info]
│   ├── Next Release [number]
│   │   ├── Details
│   │   ├── [Applicable Links/Extra Info]
|   ├── Release [number] -- repeated as relevant
│   │   ├── Details
│   │   ├── [Applicable Links/Extra Info]
|   ├── In the future
│   │   ├── Details
│   │   ├── [Applicable Links/Extra Info]
```
## 4/29/2015
### Current Release - v0.1.0
#### Details
- View all issues for the requested repository - including comments.
- After entering a user name, the repository picker is pre-populated with the user/org repos.
- Clicking on the title of an `issue` will open the `issue` on github using the default action as set by the users machine

### Next release - v0.2.0
#### Details
- Allow sign-in using `OAuth`, without persistance between program runs.
- If signed in, github user picker defaults to current user.

### Next Release - v0.3.0
#### Details
- Add view of all issues for given user/org.
- If signed in default to this view -and load the data.

#### Extra Info
- The `Issue` model will need to be updated to provide the `repo` and `user` name.
