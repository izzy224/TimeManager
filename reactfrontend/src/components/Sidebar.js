import {
  Box,
  Button,
  Drawer,
  DrawerCloseButton,
  DrawerContent,
  useDisclosure,
} from "@chakra-ui/react";
import React from "react";
import SidebarContent from "./SidebarContent";

const Sidebar = ({ selectedDate, setSelectedDate }) => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  return (
    <>
      <Box h="94vh" w="25vw">
        <Button ml="8" mt="5" onClick={onOpen}>
          Menu
        </Button>
        <Drawer
          autoFocus={false}
          placement="left"
          onClose={onClose}
          isOpen={isOpen}
          returnFocusOnClose={false}
          onOverlayClick={onClose}
        >
          <DrawerContent>
            <SidebarContent
              selectedDate={selectedDate}
              setSelectedDate={setSelectedDate}
              onClose={onClose}
            ></SidebarContent>
          </DrawerContent>
        </Drawer>
      </Box>
    </>
  );
};

export default Sidebar;
