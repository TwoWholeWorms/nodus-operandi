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
use Doctrine\Common\DataFixtures\DependentFixtureInterface;

class Network extends AbstractFixture implements DependentFixtureInterface
{

    public function load(ObjectManager $manager)
    {
        $networks = [
            ['name' => 'Default network', 'site_id' => 1,],
        ];

        $siteRepo = $manager->getRepository('NodusOperandi\\Entity\\Site');
        print("\n\033[1;37mInserting networks:\033[0m\n");
        foreach ($networks as $s) {
            print("    \033[0;33m{$s['name']}…\033[0m ");

            $network = new Entity\Network();
            $network->setName($s['name']);

            $site = $siteRepo->findOneById($s['site_id']);
            if (!$site) {
                print("\033[0;31mFailed, site `{$s['site_id']}` not found.\033[0m\n");
                continue;
            }
            $network->setSite($site);

            $manager->persist($network);
            $manager->flush();

            print("\033[0;32mDone.\033[0m\n");
        }
    }

    public function getDependencies()
    {
        return [
            'NodusOperandi\\Fixture\\Site',
        ];
    }

}
