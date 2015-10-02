module.exports = function(grunt) {

	// 1. All configuration goes here.
	grunt.initConfig({
		pkg: grunt.file.readJSON('package.json'),

		uglify: {
			ni: {
				src: ['frontend/resources/js/includes/bootstrap-switch.min.js', 'frontend/resources/js/ni.js'],
				dest: 'frontend/public/assets/js/ni.min.js'
			}
		},

		sass: {
			static_mappings: {
				options: {
					style: 'compressed'
				},
				files: {
					'frontend/public/assets/css/ni.min.css': 'frontend/resources/sass/ni.scss'
				}
			}
		},

		watch: {
			options: {
				livereload: true,
			},
			scripts: {
				files: ['frontend/resources/js/**/*.js', '!frontend/resources/js/build/**/*.js'],
				tasks: ['uglify'],
				options: {
					spawn: false,
				},
			},
			css: {
				files: ['frontend/resources/sass/**/*.scss'],
				tasks: ['sass'],
				options: {
					spawn: false,
				},
			}
		}

	});

	// 3. Where we tell Grunt we plan to use this plug-in.
	grunt.loadNpmTasks('grunt-contrib-uglify');
	grunt.loadNpmTasks('grunt-contrib-sass');
	grunt.loadNpmTasks('grunt-contrib-watch');

	// 4. Where we tell Grunt what to do when we type "grunt" into the terminal.
	grunt.registerTask('default', ['uglify', 'sass', 'watch']);

}
