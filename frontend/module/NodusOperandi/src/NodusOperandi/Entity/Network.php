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
use VinariCore\Entity\AbstractEntity;
use VinariCore\Exception\InvalidArgumentException;

/**
 * @ORM\Entity
 */
class Network extends AbstractEntity
{

    /**
     * @var Site
     *
     * @ORM\JoinColumn(name="site_id", referencedColumnName="id", nullable=true)
     * @ORM\ManyToOne(targetEntity="Site", cascade={"all"})
     */
    protected $site;

    /**
     * @var string
     *
     * @ORM\Column(name="name", type="string", length=128, nullable=false)
     */
    protected $name;


    public function __construct()
    {
        parent::__construct();
    }


    /**
     * Gets the value of site.
     *
     * @return Site
     */
    public function getSite()
    {
        return $this->site;
    }

    /**
     * Sets the value of site.
     *
     * @param Site $site the site
     *
     * @return self
     */
    public function setSite(Site $site)
    {
        $this->site = $site;

        return $this;
    }

    /**
     * Gets the value of name.
     *
     * @return string
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * Sets the value of name.
     *
     * @param string $name the name
     *
     * @return self
     */
    public function setName($name)
    {
        if (!is_string($name)) {
            throw new InvalidArgumentException('$name must be a string; `' . gettype($name) . '` passed.');
        }
        $this->name = $name;

        return $this;
    }

}