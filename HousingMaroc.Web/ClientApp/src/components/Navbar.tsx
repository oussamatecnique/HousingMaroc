import React from 'react'
import { NavigationMenu, NavigationMenuItem, NavigationMenuLink, NavigationMenuList } from '../@/components/ui/navigation-menu'
import { useTranslation } from 'react-i18next';

const navigationMenuTriggerStyle = () => {
    return "text-white no-underline hover:underline p-2";
}
const Navbar = () => {

    const [t] = useTranslation();
    return (
        <div className="bg-black p-2">
            <NavigationMenu>
                <NavigationMenuList className="flex space-x-8">
                    <NavigationMenuItem>
                        <NavigationMenuLink href='/' className={navigationMenuTriggerStyle()}>
                            {t('home')}
                        </NavigationMenuLink>
                    </NavigationMenuItem>
                    <NavigationMenuItem>
                        <NavigationMenuLink href="/Rent" className={navigationMenuTriggerStyle()}>
                            {t('rent')}
                        </NavigationMenuLink>
                    </NavigationMenuItem>
                    <NavigationMenuItem>
                        <NavigationMenuLink href="/Sell" className={navigationMenuTriggerStyle()}>
                            {t('sell')}
                        </NavigationMenuLink>
                    </NavigationMenuItem>
                </NavigationMenuList>
            </NavigationMenu>
        </div>
    )
}

export default Navbar