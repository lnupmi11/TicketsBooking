const gulp = require('gulp'),
    watch = require('gulp-watch'),
    sass = require('gulp-sass'),
    autoPrefixer = require('gulp-autoprefixer'),
    useref = require('gulp-useref'),
    gulpIf = require('gulp-if'),
    uglify = require('gulp-uglify'),
    browserSync = require('browser-sync').create(),
    reload = browserSync.reload,
    minifyCss = require('gulp-csso'),
    rigger = require('gulp-rigger'),
    concat = require('gulp-concat'),
    imagemin = require('gulp-imagemin');

const paths = {
  webroot: "./wwwroot/"
};

paths.concatJsDest ='';
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean", ["clean:js", "clean:css"]);

//STYLES
gulp.task('scss', function () {
    return gulp.src('./raw/src/styles/*.scss')
        .pipe(sass({
            outputStyle: 'compressed'
        }).on('error', sass.logError))
        .pipe(autoPrefixer({
            browsers: ['last 15 version']
        }))
        // .pipe(minifyCss())
        .pipe(gulp.dest(paths.webroot + 'css/'))
        .pipe(reload({ stream: true }));
});

//FONTS
gulp.task('fonts', function () {
    return gulp.src(['./raw/src/fonts/**/*.*', './node_modules/@fortawesome/fontawesome-free/webfonts/*'])
        .pipe(gulp.dest(paths.webroot + 'fonts/'));
});


//SCRIPTS

gulp.task('js', function () {
    return gulp.src([
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/@fortawesome/fontawesome-free/js/all.js',
        './raw/src/scripts/main.js'
    ])
        .pipe(concat('main.min.js'))
        .pipe(gulpIf('*.js', uglify()))
        .pipe(gulp.dest(paths.webroot+'js'))
        .pipe(reload({ stream: true }));
});

//WATCH
gulp.task('watch', function () {
    watch('./raw/src/styles/**/*.scss', function () {
        gulp.start('scss');
    });
    watch('./raw/src/scripts/**/*.js', function () {
        gulp.start('js');
    });
});

//BUILD
gulp.task('build', [
    'scss',

    'js',

    'fonts'
]);

gulp.task('default', ['build', 'watch']);