import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private accountService: AccountService, private router: Router){}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        if (this.accountService.isLoggedIn()) {
            return true;
        }
        this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}