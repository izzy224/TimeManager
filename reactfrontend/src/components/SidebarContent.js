import { AddIcon, CalendarIcon, EditIcon, ViewIcon } from "@chakra-ui/icons";
import { Box, CloseButton, Flex, Text } from "@chakra-ui/react";
import React from "react";
import NavItem from "./NavItem";

const SidebarContent = ({ onClose, ...rest }) => {
  return (
    <>
      <Box boxShadow="dark-lg" w={{ base: "full" }} pos="fixed" h="full">
        <Flex h="20" alignItems="center" mx="8" justifyContent="space-between">
          <Text fontSize="2xl" fontFamily="monospace" fontWeight="bold">
            Logo
          </Text>
          <CloseButton
            display={{ base: "flex", md: "none" }}
            onClick={onClose}
          />
        </Flex>
        <NavItem name="Home" address="/home" icon={ViewIcon}>
          To Do
        </NavItem>
        <NavItem name="To Do" address="/todos" icon={CalendarIcon}>
          To Do
        </NavItem>
        <NavItem name="Schedule" address="/schedule" icon={EditIcon}>
          Schedule
        </NavItem>
        <NavItem name="Finances" address="/finances" icon={AddIcon}>
          Finances
        </NavItem>
      </Box>
    </>
  );
};

export default SidebarContent;
