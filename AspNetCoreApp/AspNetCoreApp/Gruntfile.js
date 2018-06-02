/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    require("load-grunt-tasks")(grunt);

    grunt.initConfig({
        //cssmin: {
        //    target: {
        //        files: [{
        //            expand: true, // Recursive
        //            src: ['Content/**/*.css', '!Content/**/*.min.css'], // Source files
        //            dest: '',
        //            ext: '.min.css' // File extension 
        //        }]
        //    }
        //},
        babel: {
            options: {
                sourceMap: true,
                presets: ['es2015']
            },
            dist: {
                files: [{
                    expand: true, // Recursive
                    src: 'wwwroot/js/**/*.es6.js', // Source files
                    dest: '',
                    ext: '.js' // File extension 
                }]
            }
        },
        uglify: {
            target: {
                files: [{
                    expand: true, // Recursive
                    src: ['wwwroot/js/**/*.js', '!wwwroot/js/**/*.es6.js', '!wwwroot/js/**/*.min.js'], // Source files
                    dest: '',
                    ext: '.min.js' // File extension 
                }]
            }
        },
        //watch: {
        //    css: {
        //        files: '**/*.scss',
        //        tasks: ['sass', 'cssmin']
        //    },
        //    es6: {
        //        files: '**/*.es6.js',
        //        tasks: ['babel', 'uglify']
        //    }
        //}
    });

    //grunt.loadNpmTasks('grunt-contrib-sass');
    //grunt.loadNpmTasks('grunt-contrib-watch');
    //grunt.loadNpmTasks('grunt-contrib-uglify');
    //grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.registerTask('default', ['watch']);
};