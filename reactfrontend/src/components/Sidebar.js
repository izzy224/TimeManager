import { Box, useDisclosure } from "@chakra-ui/react";
import React from "react";

const Sidebar = () => {
  const { isOpen, onOpen, onClose } = useDisclosure();
  return (
    <>
      <Box minH="100vh">
        <SidebarContent />
      </Box>
    </>
  );
};

export default Sidebar;
