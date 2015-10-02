<?php
/**
 * This makes our life easier when dealing with paths. Everything is relative
 * to the application root now.
 */
chdir(dirname(__DIR__));

// Decline static file requests back to the PHP built-in webserver
if (php_sapi_name() === 'cli-server') {
    $path = realpath(__DIR__ . parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH));
    if (__FILE__ !== $path && is_file($path)) {
        return false;
    }
    unset($path);
}

if (!defined('APPLICATION_ENV')) {
    $env = (isset($_SERVER['APPLICATION_ENV']) && in_array($_SERVER['APPLICATION_ENV'], ['production', 'staging', 'testing', 'development'])
            ? $_SERVER['APPLICATION_ENV'] : (getenv('APPLICATION_ENV')
                    ? getenv('APPLICATION_ENV') : false));
    if ($env) {
        define('APPLICATION_ENV', $env);
    } else {
        print('<div style="margin:0 auto;width:700px;box-sizing:border-box;padding:30px;color:#777;border:1px solid #ccc;font-family:Arial,sans-serif"><h1>Initialisation errors</h1>');
        print('<h2><span style="color:#900;font-weight:700;">Error:</span> <tt>APPLICATION_ENV</tt> is not defined.</h2><p>Please add <tt>fastcgi_param APPLICATION_ENV development;</tt> to your nginx fastcgi_params file, or <tt>SetEnv APPLICATION_ENV development</tt> to your Apache vhost block.</p>');
        print('</div>');
        die();
    }
}

// Setup autoloading
require 'init_autoloader.php';

// Run the application!
Zend\Mvc\Application::init(require 'config/application.config.php')->run();
