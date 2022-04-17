import { mainTypes } from '../reducers/constants';

const switchTab = () => {
    return (dispatch) => {
        dispatch({
            type: mainTypes.switchTab
        });
    }
}

const setError = (flag) => {
    return (dispatch) => {
        dispatch({
            type: mainTypes.setError,
            payload: { isError: flag }
        });
    }
}

const setRole = (role) => {
    return (dispatch) => {
        dispatch({
            type: mainTypes.setRole,
            payload: { role: role }
        });
    }
}

const setErrorText = (text) => {
    return (dispatch) => {
        dispatch({
            type: mainTypes.setError,
            payload: {errorText: text}
        });
    }
}

const clearMainState = () => {
    return (dispatch) => {
        dispatch({
            type: mainTypes.clear,
        });
    }
}

export {
    switchTab,
    setRole,
    setError,
    setErrorText,
    clearMainState
}