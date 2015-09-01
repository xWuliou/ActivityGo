require.config({
    baseUrl: '',

    // alias libraries paths.  Must set 'angular'
    paths: {
        'app': 'scripts/app/app',
        'angular': 'scripts/lib/angular',
        'angular-route': 'scripts/lib/angular-route',
        'angular-ui-router': 'scripts/lib/angular-ui-router',
        'angularAMD': 'scripts/lib/angularAMD',
        'ngload': 'scripts/lib/ngload',
        'angular-resource': 'scripts/lib/angular-resource',
        'utility': 'scripts/app/utility'
        
    },

    // Add angular modules that does not support AMD out of the box, put it in a shim
    shim: {
        'angular-route': ['angular'],
        'angularAMD': ['angular'],
        'ngload': ['angularAMD'],
        'angular-resource': ['angular'],
        'angular-ui-router': ['angular']
    },

    // kick start application
    deps: ['app']
});
