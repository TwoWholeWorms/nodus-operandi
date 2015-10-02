<?php

/**
 * NodusOperandi
 *
 * @link      http://github.com/TwoWholeWorms/nodus-operandi
 * @copyright Copyright (c) 2015 Vinari Ltd. (http://vinari.co.uk)
 * @license   MIT license (see [LICENSE](LICENSE))
 */

namespace NodusOperandi\Fixture;

use Doctrine\Common\Persistence\ObjectManager;
use Doctrine\Common\DataFixtures\FixtureInterface;
use Zend\ServiceManager\ServiceLocatorAwareInterface;
use Zend\ServiceManager\ServiceLocatorInterface;
use VinariCore\Fixture\AbstractFixture;
use NodusOperandi\Entity;

class Site extends AbstractFixture
{

    public function load(ObjectManager $manager)
    {
        $sites = [
            ['name' => 'Default site',],
        ];

        print("\n\033[1;37mInserting sites:\033[0m\n");
        foreach ($sites as $s) {
            print("    \033[0;33m{$s['name']}…\033[0m ");

            $site = new Entity\Site();
            $site->setName($s['name']);

            $manager->persist($site);
            $manager->flush();

            print("\033[0;32mDone.\033[0m\n");
        }
    }

}
