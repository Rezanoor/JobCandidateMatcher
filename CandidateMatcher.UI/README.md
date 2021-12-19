# ContributionPortal

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.0.8.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).


## 🧙‍♂️ Commands

| Command      | Description                                      | NPM                | Yarn            | Background command                                              |
| ------------ | ------------------------------------------------ | ------------------ | --------------- | --------------------------------------------------------------- |
| ng           | See available commands                           | npm run ng         | yarn ng         | ng                                                              |
| dev          | Run your app in development mode & open app      | npm run dev        | yarn dev        | ng serve -o                                                     |
| start        | Run your app in development mode                 | npm start          | yarn start      | ng serve                                                        |
| start:es     | Run your app in development mode in spanish      | npm run start:es   | yarn start:es   | ng serve -c=es --port 4201                                      |
| build        | Build your app                                   | npm run build      | yarn build      | ng build                                                        |
| build:prod   | Build your app ready for production              | npm run build:prod | yarn build:prod | ng build --prod --build-optimizer --aot --stats-json            |
| build:i18n   | Build your multilingual app ready for production | npm run build:i18n | yarn build:i18n | ng build --prod --build-optimizer --aot --stats-json --localize |
| test         | Run your unit tests                              | npm run test       | yarn test       | ng test                                                         |
| lint         | Use ESLint to lint your app                      | npm run lint       | yarn lint       | ng lint                                                         |
| e2e          | Run your e2e integration tests                   | npm run e2e        | yarn e2e        | ng e2e                                                          |
| i18n:extract | Extract i18n messages from i18n directives       | npm run extract    | yarn extract    | ng extract-i18n --output-path locale --ivy                      |
| analyze      | Open webpack-bundle-analyzer                     | npm run analyze    | yarn analyze    | webpack-bundle-analyzer dist/contribution-portal/stats.json     |
