# MovieVault

> [!NOTE]
> Provide a project title in the heading above. Just below this note write a short description of the application you plan to build.

We want to build a system to gather information about movies and TV-series like:
  - Reviews
  - Ratings
  - Summaries
  - Plots
  - Actors
  - Genre
Futhermore it will be possible to create a user, login, add non-excisting movies/TV-series and make your own reviews.


## Tech-stack

> [!NOTE]
> Write a short description of your tech-stack here in terms of programming language(s) and database engine(s).

The project will be developed in C# as a RESTful API using Entity Framework, with MSSQL as the database engine.

## Architecture

> [!NOTE]
> Write a short explanation of your planned architecture here.

We have chosen to make an API to ensure loose coupling within our project. 
This allows different UIs to interact with the system by calling the API to retrieve and manage data. 
We plan to use clean architecture, separating domain logic from application and infrastructure.
The database will be implemented by using MSSQL.


## Feature plan

> [!NOTE]
> For each week below write a short description of the features you plan to build for your project this week.

### Week 5
*Kick-off week - no features to be planned here*

### Week 6
**Feature 1:** View Movies/Series List - dummy data/seed data

**Feature 2:** View Movies/Series Details

### Week 7
*Winter vacation - nothing planned.*

### Week 8
**Feature 1:** Add Movies/Series 

**Feature 2:** Edit movie/series

### Week 9
**Feature 1:** Create user

**Feature 2:** Login user

### Week 10
**Feature 1:** Only logged-in users can add movie/series

**Feature 2:** Logout user

### Week 11
**Feature 1:** Add review to movie/series

**Feature 2:** View reviews for movie/series

### Week 12
**Feature 1:** Rate movie/series

**Feature 2:** Show average rating

### Week 13
**Feature 1:** Edit own review

**Feature 2:** Delete own review

### Week 14
*Easter vacation - nothing planned.*

### Week 15
**Feature 1:** Search movie/series by title

**Feature 2:** Filter by type (movie / tv-series)

### Week 16
**Feature 1:** View my reviews

**Feature 2:** View my created movies/series

### Week 17
**Feature 1:** Delete movie/series (owner and admin?)

**Feature 2:** Validate user
