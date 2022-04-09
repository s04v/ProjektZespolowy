import { mainTypes } from './constants';

const INITIAL_STATE = {
    tab: 0,
    isError: false,
    errorText: '',
};

const reducer = (state = INITIAL_STATE, action) => {
    switch(action.type) {
        case mainTypes.switchTab:
            return { ...state,  tab: !state.tab };
        case mainTypes.setError:
            return { ...state,  ...action.payload };
        case mainTypes.setErrorText:
            return { ...state,  ...action.payload };
        default:
            return state;
    }
};

export default reducer;


