import React from 'react';
import './styles/style.scss';
import MainPage from './pages/MainPage';

import {
    BrowserRouter,
    Routes,
    Route,
} from "react-router-dom";

const SignInPage = React.lazy(() => import ('./pages/SignInPage'));
const SignUpPage = React.lazy(() => import ('./pages/SignUpPage'));

function App() {
  return (
    <div>
        <React.Suspense fallback={<>Loading</>}>
            <BrowserRouter>
                <Routes>
                    <Route path='/' element={<MainPage />} />
                    <Route path='/signin' element={<SignInPage />} />
                    <Route path='/signup' element={<SignUpPage />} />
                </Routes>
            </BrowserRouter>
        </React.Suspense>
    </div>
  );
}

export default App;
