import { createContext, useContext } from "react";
import RideStore from "./rideStore";
import CommonStore from "./commonStore";
import CommentStore from "./commentStore";
import ModalStore from "./modelStore";
import UserStore from "./userStore";
import ProfileStore from "./profileStore";

interface Store {
    rideStore: RideStore;
    commonStore: CommonStore;
    userStore: UserStore;
    modalStore: ModalStore;
    profileStore: ProfileStore;
    commentStore: CommentStore
}

export const store: Store = {
    rideStore: new RideStore(),
    commonStore: new CommonStore(),
    userStore: new UserStore(),
    modalStore: new ModalStore(),
    profileStore: new ProfileStore(),
    commentStore: new CommentStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}