<?php

/**
 * NodusOperandi
 *
 * @link      http://github.com/TwoWholeWorms/nodus-operandi
 * @copyright Copyright (c) 2015 Vinari Ltd. (http://vinari.co.uk)
 * @license   MIT license (see [LICENSE](LICENSE))
 */

namespace NodusOperandi;

return [
    'router' => [
        'routes' => [
            'home' => [
                'type' => 'Zend\Mvc\Router\Http\Literal',
                'options' => [
                    'route'    => '/',
                    'defaults' => [
                        'controller' => 'NodusOperandi\\Controller\\Index',
                        'action'     => 'index',
                    ],
                ],
            ],
        ],
    ],
    'service_manager' => [
        'abstract_factories' => [
            'Zend\\Cache\\Service\\StorageCacheAbstractServiceFactory',
            'Zend\\Log\\LoggerAbstractServiceFactory',
        ],
        'factories' => [
            'translator' => 'Zend\\Mvc\\Service\\TranslatorServiceFactory',
        ],
    ],
    'translator' => [
        'locale' => 'en_US',
        'translation_file_patterns' => [
            [
                'type'     => 'gettext',
                'base_dir' => __DIR__ . '/../language',
                'pattern'  => '%s.mo',
            ],
        ],
    ],
    'controllers' => [
        'invokables' => [
            'NodusOperandi\\Controller\\Index' => Controller\IndexController::class
        ],
    ],
    'view_manager' => [
        'display_not_found_reason' => true,
        'display_exceptions'       => true,
        'doctype'                  => 'HTML5',
        'not_found_template'       => 'error/404',
        'exception_template'       => 'error/index',
        'template_path_stack' => [
            __DIR__ . '/../view',
        ],
    ],
    // Placeholder for console routes
    'console' => [
        'router' => [
            'routes' => [
            ],
        ],
    ],
    'doctrine' => [
        'driver' => [
            'ni_entities' => [
                'class' => 'Doctrine\\ORM\\Mapping\\Driver\\AnnotationDriver',
                'cache' => 'array',
                'paths' => [
                    __DIR__ . '/../src/NodusOperandi/Entity',
                ],
            ],
            'orm_default' => [
                'drivers' => [
                    'NodusOperandi\\Entity' => 'ni_entities',
                ],
            ],
        ],
    ],
    'data-fixture' => [
        'NodusOperandi_fixture' => __DIR__ . '/../src/NodusOperandi/Fixture',
    ],
];
