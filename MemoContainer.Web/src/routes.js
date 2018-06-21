import Memos from './components/Memo/Memos';
import SignIn from './components/Account/SignIn';
import Dashboard from './components/Dashboard';
import SignUp from './components/Account/SignUp';

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
        path: '/signup',
        component: SignUp,
        name: 'SignUp'
    },
    {
        path: '/memos',
        component: Memos,
        name: 'Memos'
    },
];