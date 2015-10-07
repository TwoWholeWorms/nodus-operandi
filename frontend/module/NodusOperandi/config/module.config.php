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
            'network' => [
                'type' => 'Zend\Mvc\Router\Http\Literal',
                'options' => [
                    'route'    => '/network',
                    'defaults' => [
                        'controller' => 'NodusOperandi\\Controller\\Network',
                        'action'     => 'index',
                    ],
                ],
            ],
            'clients' => [
                'type' => 'Zend\Mvc\Router\Http\Literal',
                'options' => [
                    'route'    => '/clients',
                    'defaults' => [
                        'controller' => 'NodusOperandi\\Controller\\Devices',
                        'action'     => 'index',
                    ],
                ],
            ],
            'alerts' => [
                'type' => 'Zend\Mvc\Router\Http\Literal',
                'options' => [
                    'route'    => '/alerts',
                    'defaults' => [
                        'controller' => 'NodusOperandi\\Controller\\Alerts',
                        'action'     => 'index',
                    ],
                ],
            ],
            'events' => [
                'type' => 'Zend\Mvc\Router\Http\Literal',
                'options' => [
                    'route'    => '/events',
                    'defaults' => [
                        'controller' => 'NodusOperandi\\Controller\\Events',
                        'action'     => 'index',
                    ],
                ],
            ],
            'settings' => [
                'type' => 'Zend\Mvc\Router\Http\Literal',
                'options' => [
                    'route'    => '/settings',
                    'defaults' => [
                        'controller' => 'NodusOperandi\\Controller\\Settings',
                        'action'     => 'index',
                    ],
                ],
            ],
            'statistics' => [
                'type' => 'Zend\Mvc\Router\Http\Literal',
                'options' => [
                    'route'    => '/statistics',
                    'defaults' => [
                        'controller' => 'NodusOperandi\\Controller\\Statistics',
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
            'NodusOperandi\\Controller\\Alerts'     => Controller\AlertsController::class,
            'NodusOperandi\\Controller\\Devices'    => Controller\DevicesController::class,
            'NodusOperandi\\Controller\\Network'    => Controller\NetworkController::class,
            'NodusOperandi\\Controller\\Events'     => Controller\EventsController::class,
            'NodusOperandi\\Controller\\Index'      => Controller\IndexController::class,
            'NodusOperandi\\Controller\\Settings'   => Controller\SettingsController::class,
            'NodusOperandi\\Controller\\Statistics' => Controller\StatisticsController::class,
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
