/// <binding BeforeBuild='17-MicroProject-Publish-All-Assets' />
var gulp = require("gulp");
var runSequence = require("run-sequence");
var open = require('gulp-open'); // Gulp browser opening plugin
var connect = require('gulp-connect'); // Gulp Web server runner plugin
var ts = require('gulp-typescript');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var cleanCss = require('gulp-clean-css');
var ConfigDestination = 'C:\\inetpub\\wwwroot\\SC92sc.dev.local\\App_Config';

var Root = 'C:\\inetpub\\wwwroot\\SC92sc.dev.local\\bin';
var Project = "D:\\TripleM-SearchUI\\src\\";
var ViewsDestination = 'C:\\inetpub\\wwwroot\\SC92sc.dev.local\\Areas';

//////////////////////////////////////////////////////
////////////// **** Foundation ****////////////////////
////////////////////////////////////////////////////

gulp.task('00---------Foundation Tasks-----------00');

gulp.task('01-MicroFoundation-Publish-Core-Dll', function () {
    gulp.src(Project + "Foundation\\Core\\code\\bin\\Debug\\Mhasasneh.Foundation.Core.dll")
        .pipe(gulp.dest(Root));
});

gulp.task('02-MicroFoundation-Publish-Core-Config', function () {

    gulp.src(Project + "Foundation\\Core\\code\\App_Config\\**\\*")
        .pipe(gulp.dest(ConfigDestination));
});

//////////////////////////////////////////////////////
////////////// **** Features ****////////////////////
////////////////////////////////////////////////////

gulp.task('03---------Features Tasks--------------01');


gulp.task('04-MicroFeature-Publish-SearchUI-Dll', function () {

    gulp.src(Project + "Feature\\SearchUI\\code\\bin\\TripleM.Feature.SearchUI.dll")
        .pipe(gulp.dest(Root));
});

gulp.task('05-MicroFeature-Publish-Views', function () {
    gulp.src(Project + 'Feature\\SearchUI\\code\\**\\*.cshtml')
        .pipe(gulp.dest(ViewsDestination));
});
gulp.task('06-MicroFeature-Publish-All', function () {
    return runSequence(
        "04-MicroFeature-Publish-SearchUI-Dll",
        "05-MicroFeature-Publish-Views");
});

//////////////////////////////////////////////////////
////////////// **** Project ****////////////////////
////////////////////////////////////////////////////

gulp.task('07---------Project Tasks--------------06');


gulp.task('08-MicroProject-Publish-Web-Dll', function () {
    gulp.src(Project + "Project\\Web\\code\\bin\\TripleM.Web.dll")
        .pipe(gulp.dest(Root));
});

gulp.task('10-MicroProject-Publish-Web-Views', function () {
    gulp.src(Project + 'Project\\Web\\code\\**\\*.cshtml')
        .pipe(gulp.dest(ViewsDestination));
});

gulp.task('11-MicroProject-Publish-All', function () {
    return runSequence(
        "08-MicroProject-Publish-Web-Dll",
        "10-MicroProject-Publish-Web-Views");
});

gulp.task('12---------Other Tasks--------------12');

// Gulp task to open the default web browser
gulp.task('12-Run-Html', function () {
    var dist = Project + "Project\\Web\\code\\Html\\";
    var url = "http://localhost:3000/";
    var port = 3000;
    connect.server({
        root: dist,
        port: port,
        livereload: true
    });

    gulp.src(dist + "index.html")
        .pipe(open({ uri: url }));
});

gulp.task('13-Ts-Compile', function () {
    var assets = ["src/Project/Web/code/Assets/**/*.ts", "src/Feature/SearchUI/code/Assets/**/*.ts"];
    gulp.src(assets)
        .pipe(ts({
            noImplicitAny: true,
            out: 'compiled-ts.js'
        }))
        .pipe(gulp.dest('src/Project/Web/code/Assets/Scripts/'));
});


// Will complie TS files and minify all JS files then will copy it to webroot
gulp.task('14-Minify-Bundle-JS', ["13-Ts-Compile"], function () {
    var jsAssets = ["src/Project/Web/code/Assets/Scripts/**/*.js", "src/Feature/SearchUI/code/Assets/Scripts/**/*.js",
        "src/Feature/Forms/code/Assets/Scripts/**/*.js","!src/Project/Web/code/Assets/Scripts/optimized.min.js"];
    return gulp.src(jsAssets)
        .pipe(uglify())
        .pipe(concat('optimized.min.js'))
        .pipe(gulp.dest('src/Project/Web/code/Assets/Scripts'))
        .pipe(gulp.dest("C:\\inetpub\\wwwroot\\SC92sc.dev.local\\Assets\\Scripts"));
});

gulp.task('15-Minify-Bundle-CSS', function () {
    var assets = ["src/Project/Web/code/Assets/**/*.css", "src/Feature/SearchUI/code/Assets/**/*.css",
         "!src/Project/Web/code/Assets/Styles/optimized.min.css"
        , "!src/Project/Web/code/Assets/Styles/css_blind/**/*.css"];
    return gulp.src(assets)
        .pipe(cleanCss())
        .pipe(concat('optimized.min.css'))
        .pipe(gulp.dest('src/Project/Web/code/Assets/Styles'))
        .pipe(gulp.dest('C:\\inetpub\\wwwroot\\SC92sc.dev.local\\Assets\\Styles'));
});

gulp.task('16-Minify-Bundle-LegacyCSS', function () {
    var assets = ["!src/Project/Web/code/LegacyAssets/Styles/legacy.optimized.min.css"
        , "src/Project/Web/code/LegacyAssets/Styles/css_blind/**/*.css"];
    return gulp.src(assets)
        .pipe(cleanCss())
        .pipe(concat('legacy.optimized.min.css'))
        .pipe(gulp.dest('src/Project/Web/code/LegacyAssets/Styles'))
        .pipe(gulp.dest('C:\\inetpub\\wwwroot\\SC92sc.dev.local\\LegacyAssets\\Styles'));
});

gulp.task('17-MicroProject-Publish-All-Assets', function () {
    var fonts = "src/Project/Web/code/Assets/Styles/Fonts\\**\\*";
    runSequence(
        '14-Minify-Bundle-JS',
        '15-Minify-Bundle-CSS',
        '16-Minify-Bundle-LegacyCSS');
    gulp.src(fonts)
        .pipe(gulp.dest("C:\\inetpub\\wwwroot\\SC92sc.dev.local\\Assets\\Styles\\Fonts"));
});

gulp.task('18---------Test Tasks--------------18');

gulp.task('18-MicroTest-Publish-SearchUI-DLL', function () {
    gulp.src(Project + "Test\\SearchUI\\code\\bin\\Debug\\TripleM.Test.SearchUI.dll")
   .pipe(gulp.dest(Root));
});

gulp.task('19-MicroTest-Publish-SearchUI-Config', function () {
    gulp.src(Project + "Test\\SearchUI\\code\\App_Config\\Include\\**\\*.config")
        .pipe(gulp.dest(ConfigDestination));
});
//publish the location folder for static HTML pages
gulp.task('20-MicroTest-Publish-Web-Html_Files', function () {
    gulp.src(Project + 'Project\\Web\\code\\Html_Files\\**\\*')
        .pipe(gulp.dest('C:\\inetpub\\wwwroot\\SC92sc.dev.local'));
});