'use strict';
const Generator = require('yeoman-generator');
const chalk = require('chalk');
const yosay = require('yosay');
const glob = require('glob');
const updateNotifier = require('update-notifier');
const pkg = require('../../package.json');

updateNotifier({
  pkg
}).notify({
  message: 'Run yo and select Update Generators to get the latest'
});

module.exports = class extends Generator {
  prompting() {
    // Have Yeoman greet the user.
    this.log(
      yosay(
        'Welcome to the\n' +
        chalk.yellow('GSN') +
        ' ' +
        chalk.bold.blue('DNN') +
        '\nproject generator! '
      )
    );

    this.log(
      chalk.white(
        'This command line tool scaffolds a DNN project/solution in the current directory.\n'
      )
    );
    this.log(
      chalk.italic.white('This tool is forked, with love, from the original ') +
      chalk.bold.blue('generator-dnn') +
      chalk.italic.white(' maintained by the most honorable Matt Rutledge.\n\n')
    );

    // Does the solution already exist? then customize the wizard
    var gOptions = { cwd: '../' };
    var globbed = glob.sync('*.sln', gOptions);
    var solutionChoice = [];

    if (globbed && globbed.length) {
      // There is a solution file in the folder above
      solutionChoice = {
        name: chalk.gray('Solution Structure'),
        value: 'solution',
        disabled: chalk.gray('Already in a solution structure')
      };
    } else {
      // This may be the first time using this in the current folder
      solutionChoice = { name: 'Solution Structure', value: 'solution' };
    }

    //
    // TODO: Add logic to look for solution folders (e.g., Modules) and disable the extensions below until the solution is created.
    // TODO: Update the primary solution file when projects are added.
    //

    const prompts = [
      {
        when: !this.options.projType,
        type: 'list',
        name: 'projType',
        message: 'What type of project would you like to scaffold?',
        choices: [
          solutionChoice,
          { name: 'Module: SPA G', value: 'spa-g' },
          { name: 'Module: MVC', value: 'mvc' },
          { name: 'Module: MVC+SPA', value: 'mvc-spa' },
          { name: 'Module: MVC, .NET Core', value: 'mvc-core' },
          { name: 'Module: MVC+SPA+AngularJS', value: 'mvc-spa-angularjs' },
          { name: 'Module: SPA', value: 'spa' },
          { name: 'Persona Bar', value: 'personabar' },
          { name: 'Skin Object', value: 'skinobject' },
          { name: 'Library', value: 'library' },
          { name: 'Library: Scheduled Job', value: 'library-scheduledjob' },
          { name: 'Hotcakes Commerce Extension', value: 'hcc' }
        ]
      },
      {
        when: !this.options.yourName,
        type: 'input',
        name: 'yourName',
        message: 'What\'s your first and last name (surname)?',
        store: true,
        validate: str => {
          return str.length > 0;
        }
      },
      {
        when: !this.options.company,
        type: 'input',
        name: 'company',
        message: 'Namespace for your solution (Usually a company name, such as \'Upendo\' if you were Upendo Ventures)?',
        store: true,
        validate: str => {
          return str.length > 0;
        }
      },
      {
        when: !this.options.companyUrl,
        type: 'input',
        name: 'companyUrl',
        message: 'Company Website:',
        store: true,
        validate: str => {
          return str.length > 0;
        }
      },
      {
        when: !this.options.emailAddy,
        type: 'input',
        name: 'emailAddy',
        message: 'Your e-mail address:',
        store: true,
        validate: str => {
          return str.length > 0;
        }
      }
    ];

    return this.prompt(prompts).then(props => {
      // To access props later use this.props.someAnswer;
      this.props = props;
    });
  }

  composing() {
    const options = {
      projType: this.props.value,
      yourName: this.props.yourName,
      company: this.props.company,
      companyUrl: this.props.companyUrl,
      emailAddy: this.props.emailAddy
    };

    this.composeWith(require.resolve('../' + this.props.projType), options);
  }

  writing() { }

  install() { }
};
