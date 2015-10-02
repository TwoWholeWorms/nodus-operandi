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

class User extends AbstractFixture
{

    public function load(ObjectManager $manager)
    {
        $users = [
            ['display_name' => 'Admin', 'email' => 'admin@example.com', 'password' => '$2y$14$/30Gj2lhwqzNglTGF/dfO.7T3H6cMW.CeghcZll6wQ2RLWxygBs2y',],
        ];

        print("\n\033[1;37mInserting users:\033[0m\n");
        foreach ($users as $u) {
            print("    \033[0;33m{$u['email']}…\033[0m ");

            $user = new Entity\User();
            $user->setDisplayName($u['display_name']);
            $user->setEmail($u['email']);
            $user->setPassword($u['password']);

            $manager->persist($user);
            $manager->flush();

            print("\033[0;32mDone.\033[0m\n");
        }
    }

}
