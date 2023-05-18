# _Best Restaurants_

#### By _**Joe Wilfong & Eusebie Siebenberg**_

#### An website where users can add their favorite restaurants based on the type of cuisine they offer.

## Technologies Used

* _C#_
* _MySQL Workbench_
* _Razor_
* _ASP.NET Core MVC_
* _VS Code_
* _.NET6_
* _Command Line_

## Setup/Installation Requirements

1. _Open your shell of choice (e.g., Terminal or GitBash) and run these commands in order:_
2. _Clone this repository by running $ `git clone https://github.com/user/examplerepo.git` (replace url with link copied from github)_
3. _Navigate to this project's production directory called "BestRestaurants" with $ `cd BestResaurants`._
4. Within the production directory "BestRestaurants", create a new file called `appsettings.json`.
5. Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL. For the LearnHowToProgram.com lessons, we always assume the `uid` is `root` and the `pwd` is `epicodus`.

```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=best_restaurants;uid=root;pwd=epicodus;"
  }
}
```
6. Within the production directory "BestRestaurants", run `dotnet watch run` in the command line to start the project in development mode with a watcher.

## Known Bugs 

* _No known bugs_

## [MIT](https://opensource.org/license/mit/) License

Copyright (c) 5/18/2023, Joe Wilfong & Eusebie Siebenberg

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

If you have any questions, comments, or concerns, please reach out to us at: siebenee@gmail.com