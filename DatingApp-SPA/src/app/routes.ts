/* Specify the routes of our application */
import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    // The order is important, because it trys to match the paths one by one
    { path: '', component: HomeComponent }, /* home link should be empty because we cont have a route for an empty path */
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard], /* Set the canActivate for all the children */
        children: [
            { path: 'members', component: MemberListComponent }, /* '' + 'members' */
            { path: 'messages', component: MessagesComponent },
            { path: 'lists', component: ListsComponent },
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' } // Redirect everithing that doesnt match the previus Paths to home
];
