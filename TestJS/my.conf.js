module.exports = function (config) {
    config.set({
        basePath: '',
        frameworks: ['jasmine'],
        files: [
          '*.js',
          'spec/*.js'
        ],
        browsers: ['Chrome'],
        singleRun: true,
        reporters: ['progress', 'coverage','junit','html'],        
        preprocessors: { '*.js': ['coverage'] }
    });
};