/*jshint node:true */

module.exports = function (grunt) { 'use strict';

    // load all grunt tasks
    require('load-grunt-tasks')(grunt);

    // show elapsed time at the end
    require('time-grunt')(grunt);

    grunt.initConfig({
        config: {
            css: {
                dest: 'wwwroot/css',
                src: 'Assets/Styles'
            }
        },
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib",
                    layout: "byComponent",
                    cleanTargetDir: false
                }
            }
        },
        less: {
            styles: {
                files: {
                    '<%= config.css.dest %>/site.css': [
                        '<%= config.css.src %>/site.less']
                }
            }
        },
        jshint: {
            options: {
                reporter: require('jshint-stylish')
            },
            scripts: {
                src: ['gruntfile.js', 'scripts/**/*.js']
            }
        }
    });

    // Registers tasks
    grunt.registerTask("default", ["bower:install"]);
    grunt.registerTask("build", ["less"]);
};