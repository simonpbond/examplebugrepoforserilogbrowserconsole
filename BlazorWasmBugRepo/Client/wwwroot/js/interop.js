window.SessionStorage = {

    // Save data to sessionStorage
    setSessionStorage: function (key, value) {
        console.log("INTR: Session-Storage-setSessionStorage with key: " + key + " and value: " + value);
        sessionStorage.setItem(key, value);
    },

    // Get saved data from sessionStorage
    getSessionStorage: function (key) {
        console.log("INTR: Session-Storage-getSessionStorage with key: " + key);
        var value = sessionStorage.getItem(key);
        console.log("INTR: Session-Storage-getSessionStorage with key: [" + key + "] , returned value: [" + value + "]");
        return value;
    }

};