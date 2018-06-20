import Memos from './components/Memo/Memos';
import SignIn from './components/Account/SignIn';
import Dashboard from './components/Dashboard';

export const routes = [{
        path: '/',
        component: Dashboard,
        name: 'Dashboard'
    },
    {
        path: '/signin',
        component: SignIn,
        name: 'SignIn'
    },
    {
        path: '/memos',
        component: Memos,
        name: 'Memos'
    },
];