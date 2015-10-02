<?php

/**
 * NodusOperandi
 *
 * @link      http://github.com/TwoWholeWorms/nodus-operandi
 * @copyright Copyright (c) 2015 Vinari Ltd. (http://vinari.co.uk)
 * @license   MIT license (see [LICENSE](LICENSE))
 */

namespace NodusOperandi\Entity;

use Doctrine\ORM\Mapping as ORM;
use Doctrine\Common\Collections\ArrayCollection;
use VinariCore\Entity\AbstractUser;
use VinariCore\Exception\InvalidArgumentException;

/**
 * @ORM\Entity
 */
class User extends AbstractUser
{


    public function __construct()
    {
        parent::__construct();
    }


}
